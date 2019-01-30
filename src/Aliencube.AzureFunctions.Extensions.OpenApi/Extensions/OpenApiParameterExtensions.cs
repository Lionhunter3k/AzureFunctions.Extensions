﻿using System;
using System.Collections.Generic;

using Microsoft.OpenApi.Models;

namespace Aliencube.AzureFunctions.Extensions.OpenApi.Extensions
{
    /// <summary>
    /// This represents the extension entity for <see cref="OpenApiParameter"/>.
    /// </summary>
    public static class OpenApiParameterExtensions
    {
        /// <summary>
        /// Adds <see cref="OpenApiParameter"/> instance to the collection of parameters.
        /// </summary>
        /// <typeparam name="T">Type of parameter.</typeparam>
        /// <param name="parameters">List of <see cref="OpenApiParameter"/> instances.</param>
        /// <param name="name">Parameter name.</param>
        /// <param name="description">Parameter description.</param>
        /// <param name="required">Value indicating whether this parameter is required or not. Default is <c>false</c>.</param>
        /// <param name="in"><see cref="ParameterLocation"/> value. Default is <see cref="ParameterLocation.Query"/>.</param>
        /// <returns>List of <see cref="OpenApiParameter"/> instances.</returns>
        public static List<OpenApiParameter> AddOpenApiParameter<T>(
            this List<OpenApiParameter> parameters,
            string name,
            string description = null,
            bool required = false,
            ParameterLocation @in = ParameterLocation.Query)
        {
            return AddOpenApiParameter(parameters, typeof(T), name, description, required, @in);
        }

        /// <summary>
        /// Adds <see cref="OpenApiParameter"/> instance to the collection of parameters.
        /// </summary>
        /// <param name="type">Type of parameter.</param>
        /// <param name="parameters">List of <see cref="OpenApiParameter"/> instances.</param>
        /// <param name="name">Parameter name.</param>
        /// <param name="description">Parameter description.</param>
        /// <param name="required">Value indicating whether this parameter is required or not. Default is <c>false</c>.</param>
        /// <param name="in"><see cref="ParameterLocation"/> value. Default is <see cref="ParameterLocation.Query"/>.</param>
        /// <returns>List of <see cref="OpenApiParameter"/> instances.</returns>
        public static List<OpenApiParameter> AddOpenApiParameter(
            this List<OpenApiParameter> parameters,
            Type type,
            string name,
            string description = null,
            bool required = false,
            ParameterLocation @in = ParameterLocation.Query)
        {
            var typeCode = Type.GetTypeCode(type);
            var schema = new OpenApiSchema()
                             {
                                 Type = typeCode.ToDataType(),
                                 Format = typeCode.ToDataFormat()
                             };
            var parameter = new OpenApiParameter()
                                {
                                    Name = name,
                                    Description = description,
                                    Required = required,
                                    In = @in,
                                    Schema = schema
                                };
            parameters.Add(parameter);

            return parameters;
        }
    }
}