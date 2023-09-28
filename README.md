# eBayAutomation

How to Run a Test:
1.	Build the solution successfully
2.	Right Click on test and trigger Run Tests.
   
Project Details:
EbayAutomation repository consists of one AdvarraUIAutomation solution with two projects.

1.	UIAutomationLibrary Project - Library is constructed so all helper functions and locators can be saved in one place. Multiple teams can utilize this library in the organization.
   
    a.	Base: It contains the setup of the test environment. 
            •	Language: It depicts which language a test runs on since ebay is available on multiple languages this framework will support as many languages as possible.
            •	Local Configs: It depicts which device and browser a test needs to be triggered on. Currently only Chrome (Large and XS) is supported but the framework is developed in a way that a same test can be                         triggered in as many devices and browsers as required.
            •	Pages: This file consists of all helper functions used to develop a test such as FindElement, WaitForPageLoad, DefaultWait etc. This file is inherited by all files in Pages folder and Test files (such as                     EbayTests).
            •	Viewport: This file consists of Viewport enum. This depicts the size of the device. It helps the developer to depict which type of locator will be required.
  	
    b.	Locators: Locators are defined at page level. In this way all locators related to a page will be saved in one place therefore maintenance gets easier.
            •	AllListingLocators: it consists of locators in Search Result Page /All Listing Page.
            •	CartLocators: It consists of locators in Cart Page
            •	CommonLocators: It consists of locators that are commonly used in different pages. Currently not in use. 
            •	HomeLocators: It consists of Locators in Home Page
            •	ItemLocators: It consists of Locators in Items Detailed Page
  	
    c.	Pages: It consists of 4 folders and each folder consists of 4 CSharp files. Abstract file consists of Abstract class which consists of Abstract method and non-Abstract method. Abstract method is used when we have            different locators for different viewports. Non-Abstract method is used otherwise. Abstract method is implemented in its inherited viewport files as an overridden method. All the methods from the Abstract file             is called from main file which is used by Test methods. Page folder consists of the following pages folders as listed below:
            •	AllListings 
            •	Cart
            •	Home
            •	Item
  	
3.	AdvarraTests Project – This project consists of the setup required for a test case. It also consists of test data required for testing and also the test scripts with all the steps.
		   a.	Configs: It consists of a TestConfig Json file which has a main url and Configuration a test needs to be triggered on.
		   b.	TestData: It consists of the test data required by a single test case. It can also consist of a common test data that can be used by different test cases.
		   c.	Tests: It consists of a test file with test methods. 


Note: Currently Large Viewport is implemented. There is still scope for improvement. 

****
