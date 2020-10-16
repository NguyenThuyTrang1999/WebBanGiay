using WebBanGiay.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBanGiay.DAL.Models
{
    public class MenuChaRep : GenericRep<QLBanGiayContext, MenuCha>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override MenuCha Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaCha == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaCha == id);
            m = base.Delete(m); //TODO
            return m.MaCha;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion
    }
}
