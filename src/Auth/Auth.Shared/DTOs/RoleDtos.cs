namespace PeakLogix.LogixPro.Auth.Shared.DTOs;

public record RoleDto(
    string Id,
    Guid TenantId,
    string Name
);
