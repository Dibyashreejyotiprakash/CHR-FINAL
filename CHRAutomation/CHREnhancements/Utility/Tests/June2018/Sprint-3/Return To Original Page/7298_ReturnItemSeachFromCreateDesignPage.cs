﻿using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.PageObject.InstantImpact.Product_Selection;
using NUnit.Framework;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;
using CHREnhancements.PageObject.InstantImpact.Shopping_Cart;

namespace CHREnhancements.Tests.June2018.Sprint_3.Return_To_Original_Page
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _7298_ReturnItemSeachFromCreateDesignPage : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        POS_On_Demand posondemand;
        ProdctSelectionPage productselectionpage;
        ShoppingCartPage shoppingkartpage;
        ProdctSelectionPage productselectpage;
        ShoppingCartPage shoppingcartpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void ReturnToOriginalSearchPage(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            shoppingkartpage = new ShoppingCartPage(Driver);
            productselectpage = new ProdctSelectionPage(Driver);
            shoppingcartpage = new ShoppingCartPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.ClickOnPosOnDemand();
                posondemand.SelectTemplate(Testdata.templateid);
                posondemand.ClickOnCreateYourDesign();
                action.WaitForPageToLoad();
                createdesignpage.ClickOnCancel();
                posondemand.VerifyPosOnDemand();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Return to original search page is failed due to " + e);
                Assert.Fail();
            }
        }
    }
}