using System;
using System.Collections.Generic;

namespace SmartTask.Domain;

public record User(
    Guid Id,
    string Email,
    DateTime CreateDate,
    List<Device> Devices,
    List<Setting> Settings);

