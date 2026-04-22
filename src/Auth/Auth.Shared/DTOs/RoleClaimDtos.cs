namespace PeakLogix.PickPro.Auth.Shared.DTOs;

public record RoleClaimDto(
    int Id,
    string RoleId,
    string ClaimType,
    string ClaimValue
);
