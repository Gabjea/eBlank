using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlank
{
	public class User
	{
		private string username,
					   email,
					   school,
					   function,
					   id,
					   clasa; // field
		public string Name   // property
		{
			get { return username; }
			set { username = value; }
		}
		public string ClasaId   // property
		{
			get { return clasa; }
			set { clasa = value; }
		}
		public string Id   // property
		{
			get { return id; }
			set { id = value; }
		}
		public string Email   // property
		{
			get { return email; }
			set { email = value; }
		}
		public string School   // property
		{
			get { return school; }
			set { school = value; }
		}
		public string Function   // property
		{
			get { return function; }
			set { function = value; }
		}
	}
}