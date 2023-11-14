﻿
using Alba;
using BusinessClockApi.Models;

namespace BusinessClockApi.ContractTests;
public class GettingOnCallDeveloper
{

    [Fact]
    public async Task DuringBusinessHours()
    {

        var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/issue-tracker/oncall-developer");
            api.StatusCodeShouldBeOk();
        });


        var expected = new OnCallDeveloperResponse("Bob Smith", "bob@aol.com", "555-1212");
        var body = response.ReadAsJson<OnCallDeveloperResponse>();


        Assert.Equal(expected, body);


    }
    [Fact]
    public async Task OutsideBusinessHours()
    {

        var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/issue-tracker/oncall-developer");
            api.StatusCodeShouldBeOk();
        });


        var expected = new OnCallDeveloperResponse("Support Pros, Inc.", "support@pros.com", "800 592-1838");
        var body = response.ReadAsJson<OnCallDeveloperResponse>();


        Assert.Equal(expected, body);


    }
}
