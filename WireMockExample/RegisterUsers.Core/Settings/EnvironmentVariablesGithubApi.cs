using System;

namespace RegisterUsers.Core.Settings
{
    public static class EnvironmentVariablesGithubApi
    {
        public static string GithubUri => Environment.GetEnvironmentVariable("GITHUB_URI");
        public static string GithubAuth => Environment.GetEnvironmentVariable("GITHUB_AUTH");
    }
}