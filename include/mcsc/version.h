#pragma once

#include <stddef.h>
#include <stdint.h>

namespace mcsc {

using Version = union {
	uint32_t value;
	struct {
		uint8_t	 major;
		uint8_t	 minor;
		uint16_t patch;
	};
};

constexpr Version makeVersion(uint8_t major, uint8_t minor, uint16_t patch) {
	return {
		.major = major,
		.minor = minor,
		.patch = patch,
	};
}

inline bool operator==(const Version& lhs, const Version& rhs) {
	return lhs.value == rhs.value;
}

inline bool operator!=(const Version& lhs, const Version& rhs) {
	return lhs.value != rhs.value;
}

inline bool operator>(const Version& lhs, const Version& rhs) {
	return (((uint32_t)lhs.major << 24) | ((uint32_t)lhs.minor << 16) | lhs.patch) >
		   (((uint32_t)rhs.major << 24) | ((uint32_t)rhs.minor << 16) | rhs.patch);
}

inline bool operator<(const Version& lhs, const Version& rhs) {
	return (((uint32_t)lhs.major << 24) | ((uint32_t)lhs.minor << 16) | lhs.patch) <
		   (((uint32_t)rhs.major << 24) | ((uint32_t)rhs.minor << 16) | rhs.patch);
}

inline bool operator>=(const Version& lhs, const Version& rhs) {
	return !(lhs < rhs);
}

inline bool operator<=(const Version& lhs, const Version& rhs) {
	return !(lhs > rhs);
}

};	 // namespace mcsc
