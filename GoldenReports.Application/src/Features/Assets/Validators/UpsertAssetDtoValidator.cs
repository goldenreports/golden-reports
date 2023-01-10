using FluentValidation;
using GoldenReports.Application.DTOs.Assets;

namespace GoldenReports.Application.Features.Assets.Validators;

public class UpsertAssetDtoValidator : AbstractValidator<UpsertAssetDto>
{
    public UpsertAssetDtoValidator()
    {
    }
}