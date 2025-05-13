export function cleanTask(cb) {
    cb();
    return Promise.resolve('clean task');
}