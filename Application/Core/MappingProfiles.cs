using Application.DTOs;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Project, GetProjectDto>();
        CreateMap<OpenIssue, GetOpenIssueDto>();
        CreateMap<GetOpenIssueDto, OpenIssue>();
        CreateMap<TestIssue, GetTestIssueDto>();
        CreateMap<InProgressIssue, GetIssueInProgressDto>();
        CreateMap<GetIssueInProgressDto, InProgressIssue>();
        CreateMap<ClosedIssue, GetClosedIssueDto>();
    }
}