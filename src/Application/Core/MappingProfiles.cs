using Application.DTOs;
using Application.DTOs.Issues;
using AutoMapper;
using Domain.Entities;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Project, GetProjectDto>();
        CreateMap<GetProjectDto, Project>();
        CreateMap<OpenIssue, GetOpenIssueDto>();
        CreateMap<GetOpenIssueDto, OpenIssue>();
        CreateMap<IssueInReview, GetIssueInReviewDto>();
        CreateMap<GetIssueInReviewDto, IssueInReview>();
        CreateMap<InProgressIssue, GetIssueInProgressDto>();
        CreateMap<GetIssueInProgressDto, InProgressIssue>();
        CreateMap<ClosedIssue, GetClosedIssueDto>();
        CreateMap<GetClosedIssueDto, ClosedIssue>();
    }
}