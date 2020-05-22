using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbpCodeGenerator.Lib
{
    public static class Configuration
    {
        private static IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        /// <summary>
        /// 读取的程序集路径 需换成自己项目的下的程序集路径
        /// </summary>
        public static string SourceAssembly = _configuration["SourceAssembly"];

        /// <summary>
        /// 根目录 读取模板的绝对路径
        /// </summary>
        public static string RootDirectory = _configuration["RootDirectory"];

        /// <summary>
        /// 生产的类的命名空间，也可以在模板里面写死 模板都在 FileTemplates文件夹下面
        /// </summary>
        public static string Namespace_Here = _configuration["Namespace_Here"];

        /// <summary>
        /// 输出目录路径  生成的代码输出到那个项目下
        /// </summary>
        public static string Application_Directory = _configuration["Application_Directory"];

        /// <summary>
        /// Mvc输出目录路径  生成的代码输出到那个项目下
        /// </summary>
        public static string Web_Mvc_Directory = _configuration["Web_Mvc:Web_Mvc_Directory"];

        /// <summary>
        ///区域名
        /// </summary>
        public static string App_Area_Name = _configuration["Web_Mvc:App_Area_Name"];

        /// <summary>
        ///控制器基类
        /// </summary>
        public static string Controller_Base_Class = _configuration["Web_Mvc:Controller_Base_Class"];


        /// <summary>
        /// mysql数据库连接字符串
        /// </summary>
        public static string MysqlConnection = _configuration["ConnectionStrings:MysqlConnection"];

        /// <summary>
        ///数据库名称
        /// </summary>
        public static string DbName = _configuration["ConnectionStrings:DbName"];


        /// <summary>
        /// 应用服务基类
        /// </summary>
        public static string Application_AppServiceBase = _configuration["Application_AppServiceBase"];

        /// <summary>
        ///AppPermissions.cs（参考abp.zero.core 5.3.0）文件的绝对路径
        /// </summary>
        public static string AppPermissions_Path = _configuration["AppPermissions_Path"];

        /// <summary>
        ///AppAuthorizationProvider.cs（参考abp.zero.core 5.3.0）文件的绝对路径
        /// </summary>
        public static string AppAuthorizationProvider_Path = _configuration["AppAuthorizationProvider_Path"];

        /// <summary>
        ///本地化源 xml 文档（如：XinYunFen-zh-CN.xml）文件的绝对路径 （参考abp.zero.core 5.3.0）
        /// </summary>
        public static string Zh_CN_LocalizationDictionary_Path = _configuration["Zh_CN_LocalizationDictionary_Path"];




        /// <summary>
        /// 各大静态源
        /// </summary>
        public static string ConfigScore = _configuration["ConfigScore"];


        /// <summary>
        /// 需要生成代码路径
        /// </summary>
        public static string ItemPath = _configuration["ItemPath"];


        /// <summary>
        /// DbContext 得名字
        /// </summary>
        public static string DbContextName = _configuration["DbContextName"];

        /// <summary>
        /// 前端本地化源
        /// </summary>
        public static string LocalizationScore = _configuration["LocalizationScore"];

        /// <summary>
        /// 获取项目路径 .Core .Application
        /// </summary>
        /// <returns></returns>
        public static string GetItemPath(string itemName)
        {
            return $"{Configuration.ItemPath}{Configuration.ConfigScore}.{itemName}\\";
        }

    }
}
