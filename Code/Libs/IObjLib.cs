using Code.Objects;

namespace Code.Libs {

    public interface IObjLib<T> {
        public Task<T> GetObj();
    }

}