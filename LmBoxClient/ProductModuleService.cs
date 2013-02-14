﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LmBoxClient.RestController;
using LmBoxClient.Entities;
using System.Data;

namespace LmBoxClient
{
    /// <summary>
    /// C# representation of the ProductModule Service. See LmBoxAPI JavaDoc for details:
    /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/ProductModuleService.html
    /// </summary>
    public class ProductModuleService 
    {
        /// <summary>
        /// Creates new ProductModel object with given properties. See LmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/ProductModuleService.html
        /// </summary>
        public static ProductModule create(Context context, String productNumber, ProductModule newProductModule)
        {
            newProductModule.productNumber = productNumber;
            lmbox output = LmBoxAPI.request(context, LmBoxAPI.Method.POST, Constants.ProductModule.ENDPOINT_PATH, newProductModule.ToDictionary());
            return new ProductModule(output.items[0]);
        }

        /// <summary>
        /// Gets product module by its number. See LmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/ProductModuleService.html
        /// </summary>
        public static ProductModule get(Context context, String number)
        {
            lmbox output = LmBoxAPI.request(context, LmBoxAPI.Method.GET, Constants.ProductModule.ENDPOINT_PATH + "/" + number, null);
            return new ProductModule(output.items[0]);
        }

        /// <summary>
        /// Returns all product modules of a vendor. See LmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/ProductModuleService.html
        /// </summary>
        public static List<ProductModule> list(Context context, String filter)
        {
            Dictionary<String, String> parameters = new Dictionary<String, String>();
            if (filter != null && filter.Length > 0)
            {
                parameters.Add("filter", filter);
            } 

            lmbox output = LmBoxAPI.request(context, LmBoxAPI.Method.GET, Constants.ProductModule.ENDPOINT_PATH, parameters);

            List<ProductModule> productModules = new List<ProductModule>();
            foreach (item i in output.items)
            {
                productModules.Add(new ProductModule(i));
            }
            return productModules;
        }

        /// <summary>
        /// Updates product module properties. See LmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/ProductModuleService.html
        /// </summary>
        public static ProductModule update(Context context, String number, ProductModule updateProductModule)
        {
            updateProductModule.number = number;
            lmbox output = LmBoxAPI.request(context, LmBoxAPI.Method.POST, Constants.ProductModule.ENDPOINT_PATH + "/" + number, updateProductModule.ToDictionary());
            return new ProductModule(output.items[0]);
        }

        /// <summary>
        /// Deletes product module. See LmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/ProductModuleService.html
        /// </summary>
        public static void delete(Context context, String number, bool forceCascade)
        {
            String strCascade = Convert.ToString(forceCascade).ToLower();
            lmbox output = LmBoxAPI.request(context, LmBoxAPI.Method.DELETE, Constants.ProductModule.ENDPOINT_PATH + "/" + number, Utilities.forceCascadeToDict(forceCascade));
        }

    }
}
