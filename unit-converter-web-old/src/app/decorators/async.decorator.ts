export const Async = () => {
    return (target: any): void => {
        Object.defineProperty(target.prototype, 'async', {
            value: true
        });
    };
};

export const hasAsyncDecorator = (action: unknown): boolean => {
    const prototype = Object.getPrototypeOf(action);
    return !!prototype.async;
}