

namespace festival.model.validator

{
    public interface IValidator<E>
    {
        void Validate(E e);
    }
}
