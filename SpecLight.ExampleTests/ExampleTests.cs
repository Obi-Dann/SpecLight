﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions;

namespace SpecLight.ExampleTests
{
    [Trait("category", "examples")]
    [Description(@"
# Simple examples

These tests demonstrate how [SpecLight](https://github.com/robfe/speclight) works. Some of them fail on purpose, so that you can see how SpecLight behaves for failing tests.

They demonstrate:

* Failing steps
* Pending steps
* Passing steps
* Empty steps (If a step has no implementation, it will pass but SpecLight will tell you it was empty)
* Parameterised tests (`TheoryAttribute` in `xUnit`, but the same principle applies to other frameworks). These *replace* BDD-style `Scenario Outlines`
* Fixtures (Aspects that can be attached to Specs by calling WithFixture)

")]
    public class ExampleTests
    {
        List<int> numbers = new List<int>();
        int total;

        ITestOutputHelper output;
        Lazy<Exception> iPressAddException;
        public ExampleTests(ITestOutputHelper output) => this.output = output;

        [Fact]
        public void Pending()
        {
            new Spec(@"
                    Here is a spec where one of the steps will throw a NotImplementedException, causing the result of 'pending'.

                    In order to know how much money I can save
                    As a Math Idiot
                    I want to add two numbers", output.WriteLine).Tag("Pending")
                .Given(IEnter_, 5)
                .And(IEnter_, 6)
                .When(ICallAMethodThatsNotImplemented).Tag("NotImplemented")
                .Then(TheResultShouldBe_, 11)
                .Execute();
        }

        [Fact]
        public void Passing()
        {
            new Spec(@"
                    Here is a spec that should pass

                    In order to know how much money I can save
                    As a Math Idiot
                    I want to add two numbers", output.WriteLine).Tag("Money")
                .Given(IEnter_, 5)
                .And(IEnter_, 6)
                .When(IPressAdd)
                .Then(TheResultShouldBe_, 11)
                .Execute();
        }

        [Fact]
        public void Empty()
        {
            new Spec(@"
                    Sometimes you just want to write a step, and have it pass even though it does nothing
                    SpecLight detects methods that have no code and adds 'empty' to the status of 'passed'", output.WriteLine)
                .Given(EmptyMethodWithArgument_, "x")
                .And(EmptyMethodWithNoArgument)
                .Execute();
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, -2, -1)]
        [InlineData(1, 2, 35)]
        public void Theory(int i1, int i2, int sum)
        {
            new Spec(@"
                    SpecLight supports parameterized tests, but it helps if you pass a 'name' to the Execute method

                    In order to know how much money I can save
                    As a Math Idiot
                    I want to add two numbers", output.WriteLine).Tag("Money")
                .Given(IEnter_, i1)
                .And(IEnter_, i2)
                .When(IPressAdd)
                .Then(TheResultShouldBe_, sum)
                .Execute(string.Format("Theory: {0}+{1}={2}", i1, i2, sum));
        }

        [Fact]
        public void Failing()
        {
            new Spec(@"
                    Here is a spec that should fail. Steps after the failing step are skipped


                    In order to know how much money I can save
                    As a Math Idiot
                    I want to add two numbers", output.WriteLine)
                .Tag("DemonstrateFinally")
                .WithFixture<ExecutionTimer>()
                .Given(IEnter_, 5)
                .Finally(() => Console.WriteLine("Cleanup 1/2"))
                .And(IEnter_, 6)
                .When(IPressAdd)
                .Then(TheResultShouldBe_, -12013)
                .And(ICallAMethodThatsNotImplemented)
                .Finally(() => Console.WriteLine("Cleanup 2/2"))
                .Execute();
        }

        [Fact]
        public void CatchingExceptions()
        {
            new Spec(@"
                    Sometimes it's useful to check that a step throws an exception.
                    Use .Catch to store the exception for later.", output.WriteLine)
                .Given(IEnterNothing)
                .When(IPressAdd).Catch(out iPressAddException)
                .Then(UserShouldSeeAnErrorWithMessage_, "No numbers to sum!")
                .Execute();
        }

        [Fact]
        public void CatchingExceptionsEnsuresExceptionsAreInspected()
        {
            new Spec(@"
                    Sometimes it's useful to check that a step throws an exception.
                    Unread exceptions will cause the spec to fail,", output.WriteLine)
                .Given(IEnterNothing)
                .When(IPressAdd).Catch(out iPressAddException)
                .Execute(); //throws an exception, because iPressAddException.Value was never read
        }

        void UserShouldSeeAnErrorWithMessage_(string messageQuoted)
        {
            var exception = iPressAddException.Value;
            Assert.NotNull(exception);
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal(messageQuoted, exception.Message);
        }

        void IEnterNothing()
        {
            numbers.Clear();
        }


        void IPressAdd()
        {
            if (!numbers.Any())
            {
                throw new InvalidOperationException("No numbers to sum!");
            }
            total = numbers.Sum();
        }

        void TheResultShouldBe_(int obj)
        {
            Assert.Equal(obj, total);
        }

        void ICallAMethodThatsNotImplemented()
        {
            throw new NotImplementedException();
        }

        void EmptyMethodWithArgument_(string arg)
        {

        }

        void EmptyMethodWithNoArgument()
        {

        }

        void IEnter_(int obj)
        {
            numbers.Add(obj);
        }
    }

    public class ExecutionTimer : SpecFixtureBase
    {
        public override void StepSetup(Step step)
        {
            //since this class is time-sensitive, access the dictionary not the bag. Warmup can be as high as 200ms for dynamic invokes.
            step.DataDictionary["Timer"] = Stopwatch.StartNew(); //this won't get printed as it's not a string.
        }

        public override void StepTeardown(Step step)
        {
            var stopwatch = (Stopwatch)step.DataDictionary["Timer"];
            stopwatch.Stop();
            step.DataBag.ExecutionTime = stopwatch.ElapsedMilliseconds + "ms"; //this goes into the output as it's a string

            if (stopwatch.ElapsedMilliseconds > 10)
            {
                step.Tags.Add("slow");
            }
        }

        public override void SpecTeardown(Spec spec)
        {
            //note that the spec would have actually taken a lot longer to execute (SpecLight reflection overhead), but the following number is accurate for user code
            var total = spec.Steps.Select(x => (Stopwatch)x.DataBag.Timer).Sum(x => x.ElapsedMilliseconds);
            spec.DataBag.ExecutionTime = total + "ms";
        }
    }
}
