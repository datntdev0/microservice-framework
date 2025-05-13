import { series } from "gulp"

import { cleanTask } from "./gulp/clean.js"
import { buildTask } from "./gulp/build.js"

// export clean and build tasks for gulp CLI usage
export {
    cleanTask as clean,
    buildTask as buid,
}

// export default task for gulp default task
export default series(cleanTask, buildTask);
