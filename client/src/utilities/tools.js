export function month(monthNumber){
    const months = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec','Jan'];
    return months[monthNumber-1];
}

export function status(status){
    const statuses = {
        TD: 'tropical depression',
        TS: 'tropical storm',
        HU: 'hurricane',
        EX: 'extratropical cyclone',
        SD: 'subtropical depression',
        SS: 'subtropical storm',
        LO: 'low',
        WV: 'tropical wave',
        DB: 'disturbance',
        'N/A': 'system'
    };

    return statuses[status];
}

export function title(title)
{
    const firstLetter = title[0];
    const rest = title.slice(1);
    const restLower = rest.toLowerCase();

    return `${firstLetter}${restLower}`;
}

export function named(name){
    if (name.toLowerCase() === 'unnamed'){
        return `${name} Hurricane`;
    } else {
        return `Hurricane ${name}`;
    };
}