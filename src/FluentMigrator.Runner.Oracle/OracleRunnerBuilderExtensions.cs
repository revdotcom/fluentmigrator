﻿#region License
// Copyright (c) 2018, FluentMigrator Project
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using FluentMigrator.Runner.Generators.Oracle;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.DotConnectOracle;
using FluentMigrator.Runner.Processors.Oracle;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace FluentMigrator.Runner
{
    /// <summary>
    /// Extension methods for <see cref="IMigrationRunnerBuilder"/>
    /// </summary>
    public static class OracleRunnerBuilderExtensions
    {
        /// <summary>
        /// Adds Oracle support
        /// </summary>
        /// <param name="builder">The builder to add the Oracle-specific services to</param>
        /// <returns>The migration runner builder</returns>
        public static IMigrationRunnerBuilder AddOracle(this IMigrationRunnerBuilder builder)
        {
            builder.Services.TryAddScoped<OracleGenerator>();
            builder.Services
                .AddScoped<OracleDbFactory>()
                .AddScoped<OracleProcessor>()
                .AddScoped<OracleProcessorBase>(sp => sp.GetRequiredService<OracleProcessor>())
                .AddScoped<IMigrationProcessor>(sp => sp.GetRequiredService<OracleProcessor>())
                .AddScoped<OracleQuoterBase>(
                    sp =>
                    {
                        var opt = sp.GetRequiredService<IOptions<ProcessorOptions>>();
                        if (opt.Value.IsQuotingForced())
                            return new OracleQuoterQuotedIdentifier();
                        return new OracleQuoter();
                    })
                .AddScoped<IMigrationGenerator>(sp => sp.GetRequiredService<OracleGenerator>());
            return builder;
        }

        /// <summary>
        /// Adds managed Oracle support
        /// </summary>
        /// <param name="builder">The builder to add the managed Oracle-specific services to</param>
        /// <returns>The migration runner builder</returns>
        public static IMigrationRunnerBuilder AddOracleManaged(this IMigrationRunnerBuilder builder)
        {
            builder.Services.TryAddScoped<OracleGenerator>();
            builder.Services
                .AddScoped<OracleManagedDbFactory>()
                .AddScoped<OracleManagedProcessor>()
                .AddScoped<OracleProcessorBase>(sp => sp.GetRequiredService<OracleManagedProcessor>())
                .AddScoped<IMigrationProcessor>(sp => sp.GetRequiredService<OracleManagedProcessor>())
                .AddScoped<OracleQuoterBase>(
                    sp =>
                    {
                        var opt = sp.GetRequiredService<IOptions<ProcessorOptions>>();
                        if (opt.Value.IsQuotingForced())
                            return new OracleQuoterQuotedIdentifier();
                        return new OracleQuoter();
                    })
                .AddScoped<IMigrationGenerator>(sp => sp.GetRequiredService<OracleGenerator>());
            return builder;
        }

        /// <summary>
        /// Adds .Connect Oracle support
        /// </summary>
        /// <param name="builder">The builder to add the .Connect Oracle-specific services to</param>
        /// <returns>The migration runner builder</returns>
        public static IMigrationRunnerBuilder AddDotConnectOracle(this IMigrationRunnerBuilder builder)
        {
            builder.Services.TryAddScoped<OracleGenerator>();
            builder.Services
                .AddScoped<DotConnectOracleDbFactory>()
                .AddScoped<DotConnectOracleProcessor>()
                .AddScoped<IMigrationProcessor>(sp => sp.GetRequiredService<DotConnectOracleProcessor>())
                .AddScoped<OracleQuoterBase>(
                    sp =>
                    {
                        var opt = sp.GetRequiredService<IOptions<ProcessorOptions>>();
                        if (opt.Value.IsQuotingForced())
                            return new OracleQuoterQuotedIdentifier();
                        return new OracleQuoter();
                    })
                .AddScoped<IMigrationGenerator>(sp => sp.GetRequiredService<OracleGenerator>());
            return builder;
        }
    }
}
