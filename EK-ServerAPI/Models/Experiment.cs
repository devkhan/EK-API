using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EK_ServerAPI.Models
{
	public class Experiment
	{
		public enum Category
		{
			mechanics,
			energy,
			rotational,
			machine,
			uncategorized
		}
		public string exp_code { get; set; }
		public string exp_name { get; set; }
		public Category exp_category { get; set; }
		public Uri files_url { get; set; }

		public Experiment(string code, string name, string category, string url)
		{
			this.exp_code = code;
			this.exp_name = name;
			switch (category)
			{
				case "mechanics": this.exp_category = Category.mechanics; break;
				case "energy": this.exp_category = Category.energy; break;
				case "rotational": this.exp_category = Category.rotational; break;
				case "machine": this.exp_category = Category.machine; break;
				default:
					this.exp_category = Category.uncategorized;
					break;
			}
			this.files_url = new Uri(url);
		}
	}
}