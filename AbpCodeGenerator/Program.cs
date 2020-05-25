using System;
using System.IO;
using System.Text;
using System.Linq;
using AbpCodeGenerator.Lib;
using Microsoft.Extensions.Configuration;

namespace AbpCodeGenerator
{
    class Program
    {

        static void Main(string[] args)
        {


            #region 获取数据源的两种方式mysql和反射程序集
            //mysql
            //string tableName = "abpusers";//表名
            //var metaTableInfoList = MetaTableInfo.GetMetaTableInfoListForMysql(tableName);

            //反射程序集的方式生成相应代码 
            
            var metaTableInfoList = MetaTableInfo.GetMetaTableInfoListForAssembly();
            foreach (var item in metaTableInfoList)
            {
                string className = item.ClassName;//跟类名保持一致
                CodeGeneratorHelper.SetAuthorizationProvider(className);
                CodeGeneratorHelper.SetAuthorizationPermissions(className);

                //得到主键类型
                var propertyType = item.MetaTableInfos.FirstOrDefault(m => m.Name == "Id").PropertyType;
                // server端生成
                CodeGeneratorHelper.SetAppServiceIntercafeClass(className, propertyType);
                CodeGeneratorHelper.SetAppServiceClass(className, propertyType);

                CodeGeneratorHelper.SetCreateOrEditInputClass(className, item.MetaTableInfos);
                CodeGeneratorHelper.SetDeleteInputClass(className, item.MetaTableInfos, propertyType);
                CodeGeneratorHelper.SetGetAllInputClass(className, item.MetaTableInfos);
                CodeGeneratorHelper.SetGetInputClass(className, item.MetaTableInfos, propertyType);
                CodeGeneratorHelper.SetUpdateInputClass(className, item.MetaTableInfos, propertyType);
                CodeGeneratorHelper.SetDtoOutClass(className, item.MetaTableInfos, propertyType);


                CodeGeneratorHelper.SetCreateOrEditViewModelClass(className);
                CodeGeneratorHelper.SetControllerClass(className, propertyType);
                CodeGeneratorHelper.SetIndexHtmlTemplate(className, item.MetaTableInfos);
                CodeGeneratorHelper.SetCreateHtmlTemplate(className, item.MetaTableInfos);
                CodeGeneratorHelper.SetUpdateHtmlTemplate(className, item.MetaTableInfos);
                CodeGeneratorHelper.SetIndexJsTemplate(className, item.MetaTableInfos);
                CodeGeneratorHelper.SetUpdateJs(className);
            }
            #endregion
            

            
            
        }



    }
}
