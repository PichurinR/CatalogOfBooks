﻿using System.Web;
using System.Web.Optimization;

namespace BooksCatalogue
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-{version}.js",
				"~/Scripts/select2.min.js",
				"~/Scripts/knockout-3.4.2.js",
                "~/Scripts/moment.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
				"~/Scripts/jquery-ui-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
				"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/Scripts/bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
				"~/Scripts/DataTables/jquery.dataTables.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/mainjs").Include(
				"~/Scripts/BCScripts/main.js"));

			bundles.Add(new ScriptBundle("~/bundles/book").Include(
				"~/Scripts/BCScripts/book.js"));


			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/bootstrap.css",
				"~/Content/site.css",
				"~/Content/DataTables/css/jquery.dataTables.min.css",
				"~/Content/themes/base/jquery-ui.min.css"));
		}
	}
}