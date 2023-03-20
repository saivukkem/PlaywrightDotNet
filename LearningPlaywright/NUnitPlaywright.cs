using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace LearningPlaywright;

public class NUnitPlaywright : PageTest
{
    [Test]
    public async Task Test1()
    {
        await Page.GotoAsync("http://eaapp.somee.com");

        var linkLogin = Page.Locator("#loginLink");
        await linkLogin.ClickAsync();

        var username = Page.Locator("#UserName");
        await username.FillAsync("admin");
        
        var password = Page.Locator("#Password");
        await password.FillAsync("password");

        var btnLogin = Page.Locator("input", new PageLocatorOptions { HasTextString = "Log In" });
        await btnLogin.ClickAsync();
        
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }
}