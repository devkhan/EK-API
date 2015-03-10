using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EK_ServerAPI.Models;
using System.Data.Odbc;
using System.Diagnostics;
using System.Configuration;

namespace EK_ServerAPI.Controllers
{
    public class ExperimentController : ApiController
    {
		public IEnumerable<Experiment> GetAllExperiments()
		{
			List<Experiment> experiments = new List<Experiment>();
			string conn = ConfigurationManager.ConnectionStrings[1].ConnectionString;
			try
			{
				using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["MySQLHost"].ConnectionString))
				{
					connection.Open();
					using (OdbcCommand command = new OdbcCommand("SELECT * FROM experiments;", connection))
					using (OdbcDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							experiments.Add(
								new Experiment(
									reader["exp_code"].ToString(),
									reader["exp_name"].ToString(),
									reader["exp_category"].ToString(),
									reader["files_url"].ToString()));
							Trace.WriteLine(reader["exp_category"].ToString());
						}
						reader.Close();
					}
					connection.Close();
				}
			}
			catch (Exception e)
			{
				Trace.WriteLine(e);
				throw;
			}
			return experiments;
		}
    }
}
