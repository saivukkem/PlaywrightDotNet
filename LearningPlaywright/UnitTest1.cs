using LearningPlaywright.Pages;
using Microsoft.Playwright;

namespace LearningPlaywright;

public class Tests
{
    [Test]
    public async Task WithOutPw()
    {
        //Playwright
        var playwright = await Playwright.CreateAsync();
        
        //Set Browser
        await using var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false
            }
        );
        
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://eaapp.somee.com");
        
        await page.ClickAsync("#loginLink");

        await page.FillAsync("#UserName", "admin");
        await page.FillAsync("#Password", "password");
        await page.ClickAsync("text=Log in");

        var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
        Assert.That(isExist, Is.True);
    }
    
    [Test]
    public async Task TestWithPom()
    {
        //Playwright
        var playwright = await Playwright.CreateAsync();
        
        //Set Browser
        await using var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false
            }
        );
        
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://eaapp.somee.com");

        LoginPage loginPage = new LoginPage(page);
        await loginPage.ClickLoginLink();
        await loginPage.Login("admin", "password");

        var isExist = await loginPage.IsEmployeeDetailsExists();
        Assert.That(isExist, Is.True);
    }
    
    [Test]
    public async Task TestWithPomNewWay()
    {
        //Playwright
        var playwright = await Playwright.CreateAsync();
        
        //Set Browser
        await using var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false
            }
        );
        
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://eaapp.somee.com");

        LoginPageNewWay loginPage = new LoginPageNewWay(page);
        await loginPage.ClickLoginLink();
        await loginPage.Login("admin", "password");

        var isExist = await loginPage.IsEmployeeDetailsExists();
        Assert.That(isExist, Is.True);
    }
}