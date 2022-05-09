﻿using System;
using System.Threading.Tasks;
using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
	public class DiscountGrpcService
	{
		private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient; 
		public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
		{
			_discountProtoServiceClient = discountProtoServiceClient ?? throw new ArgumentNullException(nameof(discountProtoServiceClient));

		}

		public async Task<CouponModel> GetDiscount(string productName)
        {
			try
			{
				var discountRequest = new GetDiscountRequest { ProductName = productName };
				return await _discountProtoServiceClient.GetDiscountAsync(discountRequest);
            }
            catch (Exception xp)
            {

            }
			return null;
        }
	}
}
