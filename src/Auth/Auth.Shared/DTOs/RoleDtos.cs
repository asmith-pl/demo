namespace PeakLogix.PickPro.Auth.Shared.DTOs;

public record RoleDto(
    string Id,
    Guid TenantId,
    string Name
);
