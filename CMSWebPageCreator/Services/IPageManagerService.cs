using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSWebPageCreator.Models;
using CMSWebPageCreator.ViewModel;

namespace CMSWebPageCreator.Services
{
    public interface IPageManagerService
    {
        IEnumerable<PageCreate> GetPageList();
        bool DeletePage(Guid id);
        bool AddPage(PageCreate page);
        PageViewModel GetPage(string name);
        bool AddHeaderItem(HeaderInfo content);
        bool DeleteHeaderItem(HeaderInfo item);
        bool AddBodyItem(BodyInfo content);
        bool DeleteBodyItem(BodyInfo item);
        bool AddFooterItem(FooterInfo content);
        bool DeleteFooterItem(FooterInfo item);
    }
}
