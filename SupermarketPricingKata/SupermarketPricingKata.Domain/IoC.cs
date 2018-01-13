using Microsoft.Extensions.DependencyInjection;
using SupermarketPricingKata.Domain.OfferDataProvider;
using SupermarketPricingKata.Domain.OfferHandler;
using SupermarketPricingKata.Domain.StandardPricer;
using SupermarketPricingKata.Domain.TillController;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketPricingKata.Domain
{
    public class IoC
    {

        private static IServiceProvider _container;
        public static IServiceProvider Container
        {
            get
            {
                if (_container == null)
                { _container = BuildDefaultServiceCollection().BuildServiceProvider(); }
                return _container;
            }
        }

        private static ServiceCollection BuildDefaultServiceCollection()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ISpecialOfferHandler, DefaultSpecialOfferHandler>();
            services.AddSingleton<IStandardPricer, DefaultStandardPricer>();
            services.AddTransient<ITillController, DefaultTillController>();
            services.AddSingleton<IOfferDataProvider, DefaultOfferDataProvider>();

            return services;
        }

    }
}
