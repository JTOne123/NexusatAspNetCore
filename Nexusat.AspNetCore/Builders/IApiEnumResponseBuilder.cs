﻿using Nexusat.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexusat.AspNetCore.Builders
{
    public interface IApiEnumResponseBuilder<T>: IApiResponseBuilderBase
    {
        IApiEnumResponseBuilder<T> SetHttpCode(int code);
        IApiEnumResponseBuilder<T> SetStatusCode(string code);
        IApiEnumResponseBuilder<T> SetStatusCodeSuccess();
        IApiEnumResponseBuilder<T> SetStatusCodeFailed();
        IApiEnumResponseBuilder<T> SetException(Exception exception);
        IApiEnumResponseBuilder<T> SetData(IEnumerable<T> data);
        IApiEnumResponse<T> Build();
    }
}
