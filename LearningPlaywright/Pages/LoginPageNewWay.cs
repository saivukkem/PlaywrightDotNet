using Microsoft.Playwright;

namespace LearningPlaywright.Pages;

public class LoginPageNewWay
{
    private IPage _page;
    
    public LoginPageNewWay(IPage page) => _page = page;

    private ILocator _lnkLogin => _page.Locator("text=Login");
    private ILocator _txtUsername => _page.Locator("#UserName");
    private ILocator _txtPassword => _page.Locator("#Password");
    private ILocator _btnLogin => _page.Locator("text='Log in'");
    private ILocator _lnkEmployeeDetails => _page.Locator("text='Employee Details'");
    
    public async Task ClickLoginLink() => await _lnkLogin.ClickAsync();

    public async Task Login(string userName, string password)
    {
        await _txtUsername.FillAsync(userName);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
    }

    public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();
}