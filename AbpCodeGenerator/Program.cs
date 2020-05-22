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
            string className = "Teacher";//跟类名保持一致
            var metaTableInfoList = MetaTableInfo.GetMetaTableInfoListForAssembly(className);
            #endregion
            CodeGeneratorHelper.SetAuthorizationProvider(className);
            CodeGeneratorHelper.SetAuthorizationPermissions(className);

            //得到主键类型
            var propertyType = metaTableInfoList.FirstOrDefault(m => m.Name == "Id").PropertyType;
            // server端生成
            CodeGeneratorHelper.SetAppServiceIntercafeClass(className, propertyType);
            CodeGeneratorHelper.SetAppServiceClass(className, propertyType);

            CodeGeneratorHelper.SetCreateOrEditInputClass(className, metaTableInfoList);
            CodeGeneratorHelper.SetDeleteInputClass(className, metaTableInfoList, propertyType);
            CodeGeneratorHelper.SetGetAllInputClass(className, metaTableInfoList);
            CodeGeneratorHelper.SetGetInputClass(className, metaTableInfoList, propertyType);
            CodeGeneratorHelper.SetUpdateInputClass(className, metaTableInfoList, propertyType);
            CodeGeneratorHelper.SetDtoOutClass(className, metaTableInfoList, propertyType);
            
            
            CodeGeneratorHelper.SetCreateOrEditViewModelClass(className);
            CodeGeneratorHelper.SetControllerClass(className, propertyType);
            CodeGeneratorHelper.SetIndexHtmlTemplate(className, metaTableInfoList);
            CodeGeneratorHelper.SetCreateHtmlTemplate(className, metaTableInfoList);
            CodeGeneratorHelper.SetUpdateHtmlTemplate(className, metaTableInfoList);
            CodeGeneratorHelper.SetIndexJsTemplate(className, metaTableInfoList);
            CodeGeneratorHelper.SetUpdateJs(className);

            
            
        }



    }
}
