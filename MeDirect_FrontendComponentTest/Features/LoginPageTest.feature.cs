// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MeDirect_FrontendComponentTest.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("LoginPageTest")]
    public partial class LoginPageTestFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "LoginPageTest.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "LoginPageTest", "- Tried to log-in with all user types by using given credentials\r\n- ", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Standart-user should be logged in with own valid credentials")]
        [NUnit.Framework.CategoryAttribute("SU")]
        [NUnit.Framework.TestCaseAttribute("standard_user", "secret_sauce", null)]
        public void Standart_UserShouldBeLoggedInWithOwnValidCredentials(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SU"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("username", username);
            argumentsOfScenario.Add("password", password);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Standart-user should be logged in with own valid credentials", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 11
 testRunner.Given("User goes login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 12
 testRunner.And(string.Format("user enter credentials with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 13
 testRunner.When("user clicks login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 14
 testRunner.Then("user is on the \"inventory\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
 testRunner.And("user should see \"Products\" title", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("locked_out_user should not be logged in with own valid credentials")]
        [NUnit.Framework.CategoryAttribute("LOU")]
        [NUnit.Framework.TestCaseAttribute("locked_out_user", "secret_sauce", "Epic sadface: Sorry, this user has been locked out.", null)]
        public void Locked_Out_UserShouldNotBeLoggedInWithOwnValidCredentials(string username, string password, string error_Message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "LOU"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("username", username);
            argumentsOfScenario.Add("password", password);
            argumentsOfScenario.Add("error_message", error_Message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("locked_out_user should not be logged in with own valid credentials", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 25
 testRunner.Given("User goes login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 26
 testRunner.And(string.Format("user enter credentials with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
 testRunner.When("user clicks login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 28
 testRunner.Then(string.Format("user should gets the {0}", error_Message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("problem_user should be logged in with own valid credentials")]
        [NUnit.Framework.CategoryAttribute("PU")]
        [NUnit.Framework.TestCaseAttribute("problem_user", "secret_sauce", null)]
        public void Problem_UserShouldBeLoggedInWithOwnValidCredentials(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "PU"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("username", username);
            argumentsOfScenario.Add("password", password);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("problem_user should be logged in with own valid credentials", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 37
 testRunner.Given("User goes login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 38
 testRunner.And(string.Format("user enter credentials with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.When("user clicks login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.Then("user is on the \"inventory\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 41
 testRunner.And("user should see \"Products\" title", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("performance_glitch_user should be logged in with own valid credentials")]
        [NUnit.Framework.CategoryAttribute("PGU")]
        [NUnit.Framework.TestCaseAttribute("performance_glitch_user", "secret_sauce", null)]
        public void Performance_Glitch_UserShouldBeLoggedInWithOwnValidCredentials(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "PGU"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("username", username);
            argumentsOfScenario.Add("password", password);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("performance_glitch_user should be logged in with own valid credentials", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 52
 testRunner.Given("User goes login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 53
 testRunner.And(string.Format("user enter credentials with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.When("user clicks login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 55
 testRunner.Then("user is on the \"inventory\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 56
 testRunner.And("user should see \"Products\" title", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("trying to login with invalid credentials")]
        [NUnit.Framework.CategoryAttribute("NEGATIVE")]
        [NUnit.Framework.TestCaseAttribute("problem_user", "12345", "Epic sadface: Username and password do not match any user in this service", null)]
        [NUnit.Framework.TestCaseAttribute("", "secret_sauce", "Epic sadface: Username is required", null)]
        [NUnit.Framework.TestCaseAttribute("meDirect", "secret_sauce", "Epic sadface: Username and password do not match any user in this service", null)]
        [NUnit.Framework.TestCaseAttribute("performance_glitch_user", "", "Epic sadface: Password is required", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "Epic sadface: Username is required", null)]
        public void TryingToLoginWithInvalidCredentials(string username, string password, string error_Message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "NEGATIVE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("username", username);
            argumentsOfScenario.Add("password", password);
            argumentsOfScenario.Add("error_message", error_Message);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("trying to login with invalid credentials", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 66
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 67
 testRunner.Given("User goes login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 68
 testRunner.And(string.Format("user enter credentials with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
 testRunner.When("user clicks login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 70
 testRunner.Then(string.Format("user should gets the {0}", error_Message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
