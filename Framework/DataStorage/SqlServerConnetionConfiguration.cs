using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataStorage
{
	public sealed class SqlServerConnetionConfiguration
	{
		private string _cachedConnectionString;

		private string _address;
		private string _username;
		private string _password;
		private string _databaseName;
		private AuthType _authType;


		public SqlServerConnetionConfiguration()
		{
			Address = @"localhost\SQLEXPRESS";
			AuthType = AuthType.Windows;
			DatabaseName = "Pizza";
			Username = "";
			Password = "";
		}

		public string Address
		{
			get { return _address; }
			set
			{
				if(_address != value)
				{
					_address = value;
					_cachedConnectionString = null;
				}
			}
		}

		public string Username
		{
			get { return _username; }
			set
			{
				if(_username != value)
				{
					_username = value;
					_cachedConnectionString = null;
				}
			}
		}

		public string Password
		{
			get { return _password; }
			set
			{
				if(_password != value)
				{
					_password = value;
					_cachedConnectionString = null;
				}
			}
		}

		public string DatabaseName
		{
			get { return _databaseName; }
			set
			{
				if(_databaseName != value)
				{
					_databaseName = value;
					_cachedConnectionString = null;
				}
			}
		}

		public AuthType AuthType
		{
			get { return _authType; }
			set
			{
				if(_authType != value)
				{
					_authType = value;
					_cachedConnectionString = null;
				}
			}
		}

		public string GetConnectionString()
		{
			if(_cachedConnectionString != null) return _cachedConnectionString;

			var scsb = new SqlConnectionStringBuilder();

			scsb.DataSource = Address;
			scsb.InitialCatalog = DatabaseName;
			switch(AuthType)
			{
				case AuthType.Windows:
					{
						scsb.IntegratedSecurity = true;
						break;
					}
				case AuthType.SqlServer:
					{
						scsb.IntegratedSecurity = false;
						scsb.Password = Password;
						scsb.UserID = Username;
						break;
					}
			}

			return _cachedConnectionString = scsb.ToString();
		}
	}
}
