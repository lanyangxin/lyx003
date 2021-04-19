using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll;

namespace PH6_20.Controllers
{
    public class kqController : Controller
    {
        kqbll bll = new kqbll();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show(string state = "", DateTime? ctime = null, DateTime? ttime = null, int page = 1, int limit = 3)
        {
            List<kq> list = bll.Show();
            if (!string.IsNullOrEmpty(state))
            {
                list = list.Where(s => s.state.Contains(state)).ToList();
            }
            if (ctime != null)
            {
                list = list.Where(s => s.ctime > ctime).ToList();
            }
            if (ttime != null)
            {
                list = list.Where(s => s.ttime < ttime).ToList();
            }
            var _list = list.Skip((page - 1) * limit).Take(limit);
            var count = list.Count;
            var pagecount = Math.Ceiling(count * 1.0 / limit);
            return Ok(new
            {
                data = _list,
                pre = page > 1 ? page - 1 : 1,
                next = page < pagecount ? page + 1 : pagecount,
                last = pagecount,
                count = count,
            });
        }
    }
}
