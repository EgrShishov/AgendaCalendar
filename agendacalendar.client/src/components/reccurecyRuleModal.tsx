import React, {useState} from "react";
import {
    TextField,
    Select,
    MenuItem,
    FormControl,
} from '@mui/material';
import {ReccurencyRule} from "../models/reccurencyRulePatternModel.ts";
import {enGB} from "date-fns/locale";
import {DatePicker} from "react-nice-dates";

const ReccurecyRuleModal = ({setShowReccurenceModal}) => {
    const [repeatInterval, setRepeatInterval] = useState('none');

    const handleRepeatIntervalChange = (event) => {
        setRepeatInterval(event.target.value);
    }

    const [repeatIntervalType, setRepeatIntervalType] = useState(1); //days

    const handleRepeatIntervalTypeChange = (event) => {
        setRepeatIntervalType(event.target.value);
    }

    const [repeatIntervalValue, setRepeatIntervalValue] = useState(0);

    const handleRepeatIntervalValueChange = (event) => {
        setRepeatIntervalValue(event.target.value);
    }

    const [daysOfWeek, setDaysOfWeek] = useState([0]);

    const handleRepeatDayOfWeekToggle = (event) => {
        setDaysOfWeek(event.target.value);
    }

    const [repeatStartType, setRepeatStartType] = useState('never');

    const handleRepeatStartTypeChange = (event) => {
        setRepeatStartType(event.target.value);
    }

    const [repeatStartDate, setRepeatStartDate] = useState(0);

    const handleRepeatStartDateChange = (event) => {
        setRepeatStartDate(event.target.value);
    }

    const [repeatEndType, setRepeatEndType] = useState('never');

    const handleRepeatEndTypeChange = (event) => {
        setRepeatEndType(event.target.value);
    }

    const [repeatEndDate, setRepeatEndDate] = useState(0);

    const handleRepeatEndDateChange = (event) => {
        setRepeatEndDate(event.target.value);
    }

    const [interval, setInterval] = useState(1);
    const [frequency, setFrequency] = useState(0);
    const [daysOfMonth, setDaysOfMonth] = useState([0]);
    const [weeksOfMonth, setWeeksOfMonth] = useState([0]);
    const [monthsOfYear, setmonthsOfYear] = useState([0]);
    const [year, setYear] = useState(0);
    const [recurrenceDates, setRecurrenceDates] = useState([0]);
    const [startTime, setStartTime] = useState('');
    const [endTime, setEndTime] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        const rec_rule: ReccurencyRule = {
            frequency: frequency,
            interval: repeatIntervalType * repeatIntervalValue,
            daysOfWeek: daysOfWeek,
            daysOfMonth: daysOfMonth,
            weeksOfMonth: weeksOfMonth,
            monthsOfYear: monthsOfYear,
            year: year,
            recurrenceDates: {
                startTime: startTime,
                endTime: endTime,
            },
        };
        console.log(rec_rule);
        setShowReccurenceModal(false);
        //save? and return to detailsModal
    };

    return (
        <div className="my-14 w-full fixed h-screen flex justify-center items-center rounded-xl z-50">
            <div className="bg-white my-3 fixed w-4/12 h-fit rounded-xl shadow-2xl p-2 pt-4">
                <form
                    onSubmit={handleSubmit}
                    className="grid grid-cols-1/6 items-end gap-y-3.5"
                >
                    <FormControl className="w-full row-span-1 flex">
                        <span className="row-span-1 flex">Repeat: </span>
                        <Select
                            labelId="repeat-label"
                            value={repeatInterval}
                            onChange={handleRepeatIntervalChange}
                            className="w-full mb-4"
                        >
                            <MenuItem value="none">Никогда</MenuItem>
                            <MenuItem value="interval">Повторять с интервалом</MenuItem>
                        </Select>

                        {repeatInterval === 'interval' && (
                            <div className="flex items-center mb-4">
                                <span className="mr-2">Повторять с интервалом</span>
                                <input
                                    type="number"
                                    value={repeatIntervalValue}
                                    onChange={handleRepeatIntervalValueChange}
                                    className="border border-gray-300 rounded-md px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
                                />
                                <Select
                                    id="repeat-interval-type"
                                    value={repeatIntervalType}
                                    onChange={handleRepeatIntervalTypeChange}
                                    className="mr-2 w-32"
                                >
                                    <MenuItem value={1}>дни</MenuItem>
                                    <MenuItem value={7}>недели</MenuItem>
                                    <MenuItem value={12}>месяцы</MenuItem>
                                    <MenuItem value={365}>годы</MenuItem>
                                </Select>
                            </div>
                        )}

                        {repeatIntervalType !== 1 && (
                            <div className="flex flex-col">
                                <span className="text-gray-500 text-ms font-bold">Days of week:</span>
                                <div className="flex flex-wrap justify-center">
                                    {['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su'].map((day) => (
                                        <div
                                            key={day}
                                            className={`h-8 w-8 flex items-center justify-center rounded-full bg-gray-300 hover:bg-gray-400 cursor-pointer mr-2 mb-2
                                        ${daysOfWeek.includes(day) ? 'bg-orange-500 text-white' : ''}`}
                                            onClick={() => setDaysOfWeek(prevDays => prevDays.includes(day) ? prevDays.filter(item => item !== day) : [...prevDays, day])}
                                        >
                                            {day}
                                        </div>
                                    ))}
                                </div>
                            </div>
                        )}
                        <div className="row-span-1 flex items-center">
                            <div className="grid-cols-1/4 items-end gap-y-3.5">
                                {repeatInterval !== 'none' && (
                                    <div className="row-span-1 flex items-center gap-x-2.5">
                                        <div>
                                             <span
                                                 className="text-gray-400 font-semibold text-ms"
                                             >
                                                Начиная с
                                             </span>
                                            <Select
                                                labelId="repeat-end-label"
                                                id="repeat-end"
                                                value={repeatStartType}
                                                onChange={handleRepeatStartTypeChange}
                                                className="w-full mb-2"
                                            >
                                                <MenuItem value="never">Никогда</MenuItem>
                                                <MenuItem value="date">Дата</MenuItem>
                                            </Select>
                                        </div>
                                        {repeatStartType === 'date' && (
                                            <div>
                                                <span className="text-gray-400 font-semibold text-ms">
                                                    Дата начала:
                                                </span>
                                                <DatePicker
                                                    date={repeatStartDate}
                                                    onDateChange={handleRepeatStartDateChange}
                                                    format={"yyyy-MM-dd"}
                                                    locale={enGB}>
                                                    {({ inputProps, focused }) => (
                                                        <input
                                                            className={'input' + (focused ? ' -focused' : '')}
                                                            {...inputProps}
                                                            style={{ backgroundColor: "transparent"}}
                                                            placeholder="Select start time"
                                                        />
                                                    )}
                                                </DatePicker>
                                            </div>
                                        )}
                                    </div>
                                )}
                                {repeatInterval !== 'none' && (
                                    <div className="row-span-1 flex items-center gap-x-2.5">
                                        <div>
                                             <span
                                                 className="text-gray-400 font-semibold text-ms"
                                             >
                                                Заканчивая
                                             </span>
                                            <Select
                                                value={repeatEndType}
                                                onChange={handleRepeatEndTypeChange}
                                                className="w-full mb-2"
                                            >
                                                <MenuItem value="never">Никогда</MenuItem>
                                                <MenuItem value="date">Дата</MenuItem>
                                            </Select>
                                        </div>
                                        {repeatEndType === 'date' && (
                                            <div>
                                                <span className="text-gray-400 font-semibold text-ms">
                                                    Дата окончания:
                                                </span>
                                                <DatePicker
                                                    date={repeatEndDate}
                                                    onDateChange={handleRepeatEndDateChange}
                                                    format={"yyyy-MM-dd"}
                                                    locale={enGB}>
                                                    {({ inputProps, focused }) => (
                                                        <input
                                                            className={'input' + (focused ? ' -focused' : '')}
                                                            {...inputProps}
                                                            style={{ backgroundColor: "transparent"}}
                                                            placeholder="Select end date"
                                                        />
                                                    )}
                                                </DatePicker>
                                            </div>
                                        )}
                                    </div>
                                )}
                            </div>
                        </div>
                    </FormControl>
                    <div className="row-span-1 flex items-center justify-end gap-3">
                        <button
                            className="bg-gray-300 hover:bg-black/60 px-6 py-2 rounded text-white
                                            hover:scale-105 transition ease-out duration-200 transform"
                            type="button"
                            onClick={() => setShowReccurenceModal(false)}
                        >
                            <span className="text-black/60 font-semibold text-ms">Cancel</span>
                        </button>
                        <button
                            className="bg-orange-300 hover:bg-black/60 px-6 py-2 rounded text-white
                                            hover:scale-105 transition ease-out duration-200 transform"
                            type="submit"
                            onClick={handleSubmit}
                        >
                            <span className="text-white-400 font-semibold text-ms">Done</span>
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default ReccurecyRuleModal;