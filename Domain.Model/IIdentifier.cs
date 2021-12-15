using System;

namespace DomainModel
{
    public interface IIdentifier<IdType>
        where IdType: IEquatable<IdType>
    {
        IdType Id { get; }
    }
}