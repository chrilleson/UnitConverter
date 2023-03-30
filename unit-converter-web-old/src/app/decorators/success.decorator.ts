export const Success = (message: string) => {
    return (target: any): void => {
        Object.defineProperty(target.prototype, 'success', {
            value: message
        });
    };
};

export const hasSuccessDecorator = (action: unknown): boolean => {
    const prototype = Object.getPrototypeOf(action);
    return !!prototype.success;
}

export const getSucessfulMessage = (action: unknown): string => {
    const prototype = Object.getPrototypeOf(action);
    return prototype.success;
}