namespace PeakLogix.PickPro.Auth.Shared.DTOs;

public record ScopeDto(
    string Id,
    string Name,
    string? DisplayName,
    string? Description
);
