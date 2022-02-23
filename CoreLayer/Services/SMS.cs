﻿using CoreLayer.IServices;
using CORETest.Utilities;
using Kavenegar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
	public class KavenegarSMS : ISMS
	{
		public async Task<OperationResault> SendSMS(string PhoneNumber, string Text)
		{
			try
			{
				var sender = "2000500666";
				var receptor = PhoneNumber;
				var api = new KavenegarApi("386C577978465736345065515A695439436849684455713550623668744F3139684E4B2B644930472F48773D");
				var x = api.Send(sender, receptor, Text);
				return await Task.FromResult(OperationResault.Success());

			}
			catch (Exception ex)
			{
				return OperationResault.Error(ex.Message);
			}
		}
	}
	public class SibSMS : ISMS
	{
		public async Task<OperationResault> SendSMS(string PhoneNumber, string Text)
		{
			try
			{
				var httpClient = new HttpClient();
				var sender = "50002030017187";
				var response = await httpClient.GetAsync(
					$"https://www.sibsms.com/APISend.aspx?Username=09398376015&Password=1379013820&From={sender}&To={PhoneNumber}&Text={Text}");
				var res = await response.Content.ReadAsStringAsync();
				return OperationResault.Success();
			}
			catch (Exception ex)
			{
				return OperationResault.Error();
			}
		}
	}
}
