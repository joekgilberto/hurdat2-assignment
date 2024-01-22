import * as tools from '../tools';

//Creates the toFile function that has data and fileName parameters
function toFile({ data, fileName }) {
    //Iniates a new blob with the data as an argument
    const blob = new Blob([data],{ type: 'text/plain' })

    //Create a anchor for the downloadLink
    const downloadLink = document.createElement('a');

    //Sets downloadLink's download attribute to the file name
    downloadLink.download = `${fileName}.txt`;

    //Sets downloadLink's href's attribute to a URL representing the Blob object
    downloadLink.href = URL.createObjectURL(blob);

    //Adds downloadLink to the dom
    document.body.appendChild(downloadLink);

    //Calls click event
    downloadLink.click();

    //Removes downloadLink
    document.body.removeChild(downloadLink);
}

//Creates and exports downloadLandfalls function that takes a fileName and a list of hurricanes as parameters
export function downloadLandfalls(e, fileName, hurricanes) {
    //Starts the data string with the below header
    let dataString = 'HURDAT2: Hurricanes that landed in Florida, 1900 onward\n-------------------------------------------------------\n';

    //Iterates through the hurricane state, adding a string relevant information to the dataString tring for each hurricane
    for(let j = 0; j < hurricanes.length; j++){
        dataString += `${tools.named(tools.title(hurricanes[j].name))} landed in Florida on ${tools.month(hurricanes[j].month)} ${hurricanes[j].day}, ${hurricanes[j].year}.`;

        //If the hurricane is not the last on the list, \n is added to the string
        if (j < hurricanes.length-1){
            dataString += '\n'
        }
    }

    //Calls toFile passing the dataString and the file name to the funciton
    toFile({
        data: dataString,
        fileName: fileName,
    })
}

//Creates and exports downloadHurricane function that takes a fileName and a hurricane as parameters
export function downloadHurricane(e, fileName, hurricane) {
    //Starts the data string with the below header
    let dataString = `HURDAT2: ${tools.named(tools.title(hurricane.name))} (${hurricane.year})\n`;

    let underline = '';
    for (let i = 0; i < dataString.length-1; i++){
        underline += '-';
    }

    dataString += `${underline}\n`;

    //Iterates through the hurricane state's trackEntries property, adding a string representing each track entry to the dataString
    for(let j = 0; j < hurricane.trackEntries.length; j++){

        if (j === hurricane.landfallEntry){
            dataString += '*Florida Landing*\n';
        }

        dataString += `${hurricane.trackEntries[j].month}/${hurricane.trackEntries[j].day}/${hurricane.trackEntries[j].year} at ${hurricane.trackEntries[j].hour < 10 ? `0${hurricane.trackEntries[j].hour}` : hurricane.trackEntries[j].hour}:${hurricane.trackEntries[j].minute < 10 ? `0${hurricane.trackEntries[j].minute}` : hurricane.trackEntries[j].minute} UTC\nRecorded a ${tools.status(hurricane.trackEntries[j].status)} positioned at ${hurricane.trackEntries[j].latitude}${hurricane.trackEntries[j].latitudeHemisphere}, ${hurricane.trackEntries[j].longitude}${hurricane.trackEntries[j].longitudeHemisphere}  with a max wind speed of ${hurricane.trackEntries[j].maxWind}kn.`;

        //If the track entry is not the last on the list, \n\n is added to the string
        if (j < hurricane.trackEntries.length-1){
            dataString += '\n\n'
        }
    }

    //Calls toFile passing the dataString and the file name to the funciton
    toFile({
        data: dataString,
        fileName: fileName,
    })
}