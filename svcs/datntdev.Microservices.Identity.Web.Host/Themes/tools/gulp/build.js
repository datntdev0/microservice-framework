export function buildTask(cb) {
    cb();
    return Promise.resolve('build task');
}