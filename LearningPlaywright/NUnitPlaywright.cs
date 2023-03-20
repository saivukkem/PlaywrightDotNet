using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace LearningPlaywright;

public class NUnitPlaywright : PageTest
{
    [Test]
    public async Task Test1()
    {
        await Page.GotoAsync("http://eaapp.somee.com");
        
        await Page.ClickAsync("#loginLink");

        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        await Page.ClickAsync("text=Log in");
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }
}