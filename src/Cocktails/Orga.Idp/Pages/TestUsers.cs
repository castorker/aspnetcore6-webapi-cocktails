// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace Orga.Idp;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "ac46ef56-2155-4d0b-afd0-d10c5e7c89b1",
                    Username = "Johnny",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "Johnny"),
                        new Claim(JwtClaimTypes.FamilyName, "Oldman"),
                        new Claim(JwtClaimTypes.BirthDate, "11/06/2003"),
                        new Claim("role", "admin"),
                    }
                },
                new TestUser
                {
                    SubjectId = "bcc4c51b-d20b-41dc-8152-cc7ed69c62c7",
                    Username = "Linda",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "Linda"),
                        new Claim(JwtClaimTypes.FamilyName, "Young"),
                        new Claim("role", "user"),
                        new Claim(JwtClaimTypes.BirthDate, "11/06/2013"),
                    }
                }
            };
        }
    }
}