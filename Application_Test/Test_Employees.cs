using Abp.TestBase;
using CCN.DashboardCustom.UserModule.Dto;
using CCN.DashboardCustom.UserModule.UseCase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Application_Test
{
    [TestClass]
    public class Test_Employees : AbpIntegratedTestBase<TestModule>
    {
        [TestMethod]
        public void TestBulkInsert()
        {
            this.WithUnitOfWork(() =>
            {
                var service = LocalIocManager.Resolve<EmployeesService>();
                List<In_Employees> empList = new List<In_Employees>();
                //20W条数据插入测试
                for (int i = 0; i < 200000; i++)
                {
                    empList.Add(new In_Employees()
                    {
                        Id = Guid.NewGuid(),
                        Address = "Address",
                        Email = "Email",
                        Pwd = "Pwd",
                        QQ = "QQ",
                        UserName = "UserName"                   
                    });
                }
                service.BulkInsert(empList);
            });
        }
    }
}
