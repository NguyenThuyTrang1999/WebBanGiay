using System;
using System.Collections.Generic;
using System.Text;
using WebBanGiay.Common.BLL;
using WebBanGiay.Common.Rsp;
using WebBanGiay.DAL.Models;

namespace WebBanGiay.BLL
{
    class MenuChaSvc : GenericSvc<MenuChaRep,MenuCha>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(MenuCha m)
        {
            var res = new SingleRsp();

            var m1 = m.MaCha > 0 ? _rep.Read(m.MaCha) : _rep.Read(m.Descripsion);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public MenuChaSvc() { }


        #endregion
    }
}

