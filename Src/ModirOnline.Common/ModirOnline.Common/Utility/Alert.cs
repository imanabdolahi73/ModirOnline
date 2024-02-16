using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Common.Utility
{
    public static class Alert
    {
        public enum Entity
        {
            [Description("لاگ")]
            SysLog,
            [Description("طبقه بندی محصولات")]
            ProductCategory,
        }

        public static string GetInsertAlert(Entity entity)
        {
            return $"{entity.GetDescription()} با موفقیت ثبت گردید";
        }
        public static string GetDeleteAlert(Entity entity)
        {
            return $"{entity.GetDescription()} با موفقیت حذف گردید";
        }
        public static string GetUpdateAlert(Entity entity)
        {
            return $"{entity.GetDescription()} با موفقیت بروزرسانی گردید";
        }
        public enum Public
        {
            [Description("خطایی سمت سرور رخ داده است")]
            ServerException,
            [Description("موفق")]
            Success,
            [Description("ناموفق")]
            UnSuccess,
            [Description("موردی یافت نشد")]
            NotFound,
            [Description("خطای احراز هویت")]
            AuthError,
            [Description("بازیابی انجام شد")]
            Recovery,
        }
    }
}
