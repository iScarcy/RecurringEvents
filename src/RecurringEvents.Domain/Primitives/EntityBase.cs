namespace RecurringEvents.Domain.Primitives;

public abstract class EntityBase<TId>
{
    public int Id {get; set;}   

    public EntityBase(int Id)
    {
       this.Id = Id;
    }

    public override bool Equals(object? other)
    {
        if(other is null)
            return false;

        if(other.GetType() != GetType())
            return false;

        if(other is not EntityBase<TId> entity)
            return false;

        return entity.Id == Id;
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    public static bool operator ==(EntityBase<TId>? first, EntityBase<TId>? second)
    {
        if (first is null)
            return false;

        if (second is null)
            return false;

        return first is not null && second is not null && first.Equals(second) ;
    }

    public static bool operator !=(EntityBase<TId>? first, EntityBase<TId>? second)
    {
       return !(first==second) ;
    }
}