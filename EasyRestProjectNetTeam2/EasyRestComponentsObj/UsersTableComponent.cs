using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;


namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class UsersTableComponent
    {
        private WebElement _webTable;
        public UsersTableComponent(WebElement webTable)
        {
            set_webTable(webTable);
        }

        public WebElement get_webTable() {
            return _webTable;
        }

        public void set_webTable(WebElement _webTable) {
            this._webTable = _webTable;
        }

        public int getRowCount() {
            ReadOnlyCollection<IWebElement> tableRows = _webTable.FindElements(By.XPath("//tr"));
            return tableRows.Count;
        }

        public int getColumnCount() {
            ReadOnlyCollection<IWebElement> tableRows = _webTable.FindElements(By.XPath("//td"));
            IWebElement headerRow = tableRows.Count;
            List<WebElement> tableCols = headerRow.findElements(By.tagName("td"));
            return tableCols.size();
        }
    }

}
        