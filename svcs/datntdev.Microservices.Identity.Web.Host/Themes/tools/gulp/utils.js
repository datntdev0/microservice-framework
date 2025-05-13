/**
 * For each member in an object recursively
 * @param array
 * @param funcname
 * @param userdata
 * @returns {boolean}
 */
function foreachRecursively(array, funcname, userdata) {
    if (!array || typeof array !== 'object') {
        return false;
    }
    if (typeof funcname !== 'function') {
        return false;
    }

    for (let key in array) {
        // apply "funcname" recursively only on object
        if (Object.prototype.toString.call(array[key]) === '[object Object]') {
            const funcArgs = [array[key], funcname];
            if (arguments.length > 2) {
                funcArgs.push(userdata);
            }
            if (foreachRecursively.apply(null, funcArgs) === false) {
                return false;
            }
            // continue
        }
        try {
            if (arguments.length > 2) {
                funcname(array[key], key, userdata);
            }
            else {
                funcname(array[key], key);
            }
        }
        catch (e) {
            console.error('e', e);
            return false;
        }
    }
    return true;
};