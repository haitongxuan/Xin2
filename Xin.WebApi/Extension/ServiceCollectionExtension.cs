using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Xin.WebApi.Extension
{
    public static class ServiceCollectionExtension
    {
        private static IHttpContextAccessor _httpContextAccessor;

        private static IServiceProvider _serviceProvider;
        /// <summary>
        /// cerf weige
        /// </summary>
        private static IDataProtector Protector => ServiceProvider.GetDataProtector("AspNetCore", Array.Empty<string>());



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAuthorizedFilter<T>(this IServiceCollection services) where T : class, IAuthorizationFilter
        {
            services.AddTransient<IAuthorizationFilter, T>();
            return services;
        }

        /// <summary>
        /// 创建服务提供者
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static IServiceProvider RegisterServiceProvider(this IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new Exception("IServiceProvider serviceProvider canot be null");
            _httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            return serviceProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    return _httpContextAccessor.HttpContext.RequestServices;
                }
                return _serviceProvider;
            }
        }

        public static HttpContext HttpContext => _httpContextAccessor?.HttpContext;


        public static object New(Type type)
        {
            return ActivatorUtilities.CreateInstance(ServiceProvider, type, Array.Empty<object>());
        }

        public static T New<T>()
        {
            return ActivatorUtilities.CreateInstance<T>(ServiceProvider, Array.Empty<object>());
        }

        public static T Get<T>()
        {
            T val;
            try
            {
                val = ActivatorUtilities.GetServiceOrCreateInstance<T>(ServiceProvider);
            }
            catch (Exception ex)
            {
                try
                {
                    val = ServiceProvider.GetService<T>();
                }
                catch (Exception ex2)
                {
                    try
                    {
                        val = default(T);
                    }
                    catch (Exception ex3)
                    {
                        throw new Exception($"ex0={ex.Message}; ex1={ex2.Message}; ex2={ex3.Message};");
                    }
                }
            }
            if (val != null)
            {
                return val;
            }
            return default(T);
        }

        public static object Get(Type type)
        {
            try
            {
                return ActivatorUtilities.GetServiceOrCreateInstance(ServiceProvider, type);
            }
            catch
            {
                object service = ServiceProvider.GetService(type);
                if (service == null)
                {
                    return null;
                }
                return service;
            }
        }
    }
}
